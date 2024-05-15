using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfAnime.Command;
using WpfAnime.View;

namespace WpfAnime.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
		private object currentView;

		public object CurrentView
		{
			get { return currentView; }
			set { 
				currentView = value;
				OnPropertyChanged();
			}
		}

		HomeView homeView;
		UsersView usersView;

        public event PropertyChangedEventHandler? PropertyChanged;		

        public RelayCommand openHome { get; }
		public RelayCommand openUsers { get; } 

        public MainViewModel()
        {
			homeView = new HomeView();
			usersView = new UsersView();

			openHome = new RelayCommand(X=> CurrentView=homeView);
			openUsers = new RelayCommand(X=> CurrentView=usersView);

			CurrentView = homeView;
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
