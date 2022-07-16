using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApplication.Models;

namespace DoWpfApplication.DtoModels
{
    [DataContract]
    public class NodeDtoPostRequest : INotifyPropertyChanged, IDataErrorInfo
    {
        [DataMember]
        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged(nameof(Name)); } }
        [DataMember]
        private string description;
        public string Description { get => description; set { description = value; OnPropertyChanged(nameof(Description)); } }
        [DataMember]
        private int? parentId;
        public int? ParentId { get => parentId; set { parentId = value; OnPropertyChanged(nameof(ParentId)); } }
        [DataMember]
        private ObservableCollection<NodeDtoPostRequest> children;
        public ObservableCollection<NodeDtoPostRequest> Children { get => children; set { children = value; OnPropertyChanged(nameof(Children)); } }
        public string Error => null;
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(this.Name)) result = $"{nameof(Name)} mustn't be empty string";
                        break;
                    case nameof(Description):
                        if (string.IsNullOrWhiteSpace(this.Description)) result = $"{nameof(Description)} mustn't be empty string";
                        break;
                }
                return result;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public NodeDtoPostRequest(Node node)
        {
            this.Name = node.Name;
            this.Description = node.Description;
            this.ParentId = node.ParentId;
            this.Children = new ObservableCollection<NodeDtoPostRequest>(node.Children.Select(child => new NodeDtoPostRequest(child)).ToList<NodeDtoPostRequest>());
        }
        public NodeDtoPostRequest()
        {
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.Name) && !string.IsNullOrWhiteSpace(this.Description);
        }
    }
}
