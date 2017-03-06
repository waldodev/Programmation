using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tudoistoutapprendre
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string _getuser;
		private string _getpassword;
		private Brush macouleur;
		private string okcouleur;
		
		public string Getuser
		{
			get
			{
				return _getuser;
			}

			set
			{
				_getuser = value;
			}
		}
		public string Getpassword
		{
			get
			{
				return _getpassword;
			}

			set
			{
				_getpassword = value;
			}
		}

		public Brush couleur()
		{		
			
			Random alea =new Random();
			
			switch (alea.Next()%7)
			{
				case 0:
					etatconnexion.Foreground = Brushes.Yellow;
					
					break;
				case 1:
					etatconnexion.Foreground = Brushes.Green;
					break;
				case 2:
					etatconnexion.Foreground = Brushes.Gray;
					break;
				case 3:
					etatconnexion.Foreground = Brushes.MediumPurple;
					break;
				case 4:
					etatconnexion.Foreground = Brushes.OrangeRed;
					break;
				case 5:
					etatconnexion.Foreground = Brushes.Red;
					break;
				case 6:
					etatconnexion.Foreground = Brushes.RoyalBlue;
					break;
				//macouleur
				default:
					etatconnexion.Foreground = Brushes.Silver;
					break;
			}
			return etatconnexion.Foreground;
		}
		public MainWindow()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			Getuser=this.textBox.Text;
			Getpassword = this.passwordBox.Password;
			Connexion menu = new Connexion(Getuser, Getpassword);
						
			if (menu.connecter()==true)
			{
				Menu afficherMenu = new Menu();
				afficherMenu.Show();
				this.Close();
			}
			else
			{						
				etatconnexion.Visibility=Visibility;
				couleur();
				etatconnexion.Content = "Vos identifiants sont incorrects";
				
			}	
		}
	}
}
