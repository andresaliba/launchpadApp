using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;

namespace userAuthentication.Models {	

	public class WebLogin {
		// private variables
		private MySqlConnection dbConnection;
		private string connectionString;
		private MySqlCommand dbCommand;
		private MySqlDataReader dbReader;
		private HttpContext context;

		// property private variables
		private string _username;
		private string _password;
		private string _hash;
		private bool _access;

		public WebLogin(string myConnectionString, HttpContext myHttpContext) {
			// initialization
			_username = "";
			_password = "";
			_access = false;
			_hash = "";

			connectionString = myConnectionString;
			context = myHttpContext;
			// clear out the session variable
			context.Session.Clear();
		}

		// -------------------------------------------------------- gets / sets
		public string username {
			set { _username = (value == null ? "" : value); }
		}

		public string password {
			set { _password = (value == null ? "" : value); }
		}

		public bool access {
			get { return _access; }
		}

		// ------------------------------------------------------- public methods
		public bool unlock() {
			// assume no access
			_access = false;

			// trim the username / password to 10 characters
			_username = truncate(_username, 10);
			_password = truncate(_password, 10);

			try {
				dbConnection = new MySqlConnection(connectionString);
				dbConnection.Open();

				dbCommand = new MySqlCommand("SELECT password, salt FROM tblLogin WHERE username=?username", dbConnection);
				dbCommand.Parameters.AddWithValue("?username", _username);

				dbReader = dbCommand.ExecuteReader();

				// does the username exist?
				if (!dbReader.HasRows) {
					dbConnection.Close();
					return _access;
				}

				// move to the one and only record
				dbReader.Read();

				// hash and salt the entered password
				string hashedPassword = getHashed(_password, dbReader["salt"].ToString());
				// Console.WriteLine(">>> HASHED PASSWORD: " + hashedPassword);

				if (hashedPassword == dbReader["password"].ToString()) {
					_access = true;
					// store the data in the session
					context.Session.SetString("auth","true");
					context.Session.SetString("user", _username);
				}
			} finally {
				dbConnection.Close();
			}

			return _access;
		}
		// getSalt already return a random salt number
		// getHashed receives the password and the salt number, returns a hashed value

		public string newPass() {
			_username = truncate(_username, 10);
			_password = truncate(_password, 10);
			_hash = getHashed(_password, getSalt());
			return _hash;
		}

		public void logout() {
			context.Session.Clear();
		}
		// ------------------------------------------------------- private methods
		private string getSalt() {
			// generate a 128-bit salt using a secure PRNG (pseudo-random number generator)
			byte[] salt = new byte[128 / 8];
			using (var rng = RandomNumberGenerator.Create()) {
				rng.GetBytes(salt);
			}
			Console.WriteLine(">>> Salt: " + Convert.ToBase64String(salt));
			return Convert.ToBase64String(salt);
		}

		private string getHashed(string myPassword, string mySalt) {
			// convert string to Byte[] for hashing
			byte[] salt = Convert.FromBase64String(mySalt);
			// hashing done using PBKDF2 algorithm
			// derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
			string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: myPassword,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA1,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));
			Console.WriteLine(">>> Hashed: " + hashed);
			return hashed;
		}
		// cuts down [value] to [maxLength] characters
		private string truncate(string value, int maxLength) {
			return value.Length <= maxLength ? value : value.Substring(0, maxLength); 
		}
	}
}