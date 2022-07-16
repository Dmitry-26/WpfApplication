using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApplication.DtoModels;
using WpfApplication.NetServices;

namespace WpfApplication.Models
{
    public class Node : INotifyPropertyChanged
    {
        private int id;
        public int Id 
        { 
            get => id;
            set 
            { 
                id = value;
                OnPropertyChanged(nameof(Id));
            } 
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string description;

        public string Description
        {
            get 
            { 
                return description; 
            }
            set 
            { 
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private int? parentId;

        public int? ParentId
        {
            get 
            {
                return parentId;
            }
            set 
            { 
                parentId = value; 
                OnPropertyChanged(nameof(ParentId));
            }
        }

        private Node? parent;

        public Node? Parent
        {
            get 
            { 
                return parent; 
            }
            set 
            {
                parent = value; 
                OnPropertyChanged(nameof(Parent));
            }
        }

        public ObservableCollection<Node> Children { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                NodeDtoPutRequest nodeDto = new NodeDtoPutRequest(this);
                new ServerApi(new Uri("http://localhost:5250/api/node")).Update(nodeDto);
            }
        }
    }
}
