using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace tudoistoutapprendre
{
	class Connexion
	{
		private string _user;
		private string _password;
		private bool _uservalide = false;
		public string User
		{
			get
			{
				return _user;
			}

			set
			{
				_user = value;
			}
		}
		public string Password
		{
			get
			{
				return _password;
			}

			set
			{
				_password = value;
			}
		}

		public Connexion()
		{

		}
		public Connexion(string user, string password)
		{
			this._user = user;
			this._password = password;
			connecter();
		}
		///Methode
		public bool connecter()
		{
			SQLiteConnection sqlite_conn;
			SQLiteCommand sqlite_cmd;
			SQLiteDataReader sqlite_datareader;
			// create a new database connection:
			sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;");

			// open the connection:
			sqlite_conn.Open();

			//create a new SQL command:
			sqlite_cmd = sqlite_conn.CreateCommand();

			//// Let the SQLiteCommand object know our SQL-Query:
			//sqlite_cmd.CommandText = "CREATE TABLE user (iduser integer primary key,nomuser varchar(25),passuser varchar(25));";
			//sqlite_cmd.CommandText = "Insert into user(nomuser,passuser) values('visiteur','1234');";

			//// Now lets execute the SQL ;D
			//sqlite_cmd.ExecuteNonQuery();

			//// Lets insert something into our new table:
			//sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (1, 'Test Text 1');";

			//// And execute this again ;D
			//sqlite_cmd.ExecuteNonQuery();

			//// And execute this again ;D
			//sqlite_cmd.ExecuteNonQuery();

			//// But how do we read something out of our table ?
			//// First lets build a SQL-Query again:
			sqlite_cmd.CommandText = "SELECT * FROM user where nomuser='"+_user+"' and passuser='"+_password+"';";

			//// Now the SQLiteCommand object can give us a DataReader-Object:
			sqlite_datareader = sqlite_cmd.ExecuteReader();

			//// The SQLiteDataReader allows us to run through the result lines:
			while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
			{
				if (sqlite_datareader.FieldCount > 0)
				{
					//MessageBox.Show("connection ok");
					_uservalide = true;
					
				}
				else { MessageBox.Show("erreur connection"); }
				// Print out the content of the text field			
			}

			//// We are ready, now lets cleanup and close our connection:
			sqlite_conn.Close();
			return _uservalide;
		}
	}
}
