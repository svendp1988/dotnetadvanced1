using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Exercise2.Model
{
    public class Movie : INotifyPropertyChanged
    {
        private int _rating;
        public string Title { get; set; }
        public string OpeningCrawl { get; set; }

        public Movie()
        {
            _rating = 1;
            Title = string.Empty;
            OpeningCrawl = string.Empty;
        }

        public int Rating
        {
            get => _rating;
            set
            {
                if (value < 1)
                {
                    value = 1;
                }

                if (value > 5)
                {
                    value = 5;
                }
                _rating = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
