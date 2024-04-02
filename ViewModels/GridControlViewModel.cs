using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

using SF_DataGrid.Contracts.Services;
using SF_DataGrid.Helpers;
using SF_DataGrid.Models;

using Syncfusion.Windows.Shared;

namespace SF_DataGrid.ViewModels
{
    public class CustomerInfo : Observable
    {
        private string name;
        public string Name
        {
            set
            {
                name = value;
                this.OnPropertyChanged("Name");
            }
            get { return name; }
        }

        private string gender;
        public string Gender
        {
            set
            {
                gender = value;
                this.OnPropertyChanged("Gender");
            }
            get { return gender; }
        }

        private double room;
        public double Room
        {
            set
            {
                room = value;
                this.OnPropertyChanged("Room");
            }
            get { return room; }
        }
    }

    public class RoomInfo : Observable
    {
        private double number;
        public double Number
        {
            set
            {
                number = value;
                this.OnPropertyChanged("Number");
            }
            get { return number; }
        }

        private string name;
        public string Name
        {
            set
            {
                name = value;
                this.OnPropertyChanged("Name");
            }
            get { return name; }
        }
    }

    public class Gender : Observable
    {
        private string name;
        public string Name
        {
            set
            {
                name = value;
                this.OnPropertyChanged("Name");
            }
            get { return name; }
        }
    }

    public class GridControlViewModel : Observable
    {
        private ObservableCollection<RoomInfo> rooms = new ObservableCollection<RoomInfo>();
        public ObservableCollection<RoomInfo> Rooms
        {
            get
            {
                return rooms;
            }
            set
            {
                rooms = value;
                this.OnPropertyChanged("Rooms");
            }
        }

        private ObservableCollection<CustomerInfo> customerList = new ObservableCollection<CustomerInfo>();
        public ObservableCollection<CustomerInfo> CustomerList
        {
            get
            {
                return customerList;
            }
            set
            {
                customerList = value;
                this.OnPropertyChanged("CustomerList");
            }
        }

        private List<Gender> genders = new List<Gender>();

        public List<Gender> Genders
        {
            set
            {
                genders = value;
                this.OnPropertyChanged("Genders");
            }

            get { return genders; }
        }


        private void setUpCustomerList()
        {
            customerList.Add(new CustomerInfo { Name = "Sam", Gender = "Male", Room = 101 });
            customerList.Add(new CustomerInfo { Name = "Tim", Gender = "Male", Room = 102 });
            customerList.Add(new CustomerInfo { Name = "Alice", Gender = "Female", Room = 103 });
        }

        private void setUpRoomList()
        {
            rooms.Add(new RoomInfo { Name = "101", Number = 101 });
            rooms.Add(new RoomInfo { Name = "102", Number = 102 });
            rooms.Add(new RoomInfo { Name = "103", Number = 103 });
            rooms.Add(new RoomInfo { Name = "201", Number = 201 });
            rooms.Add(new RoomInfo { Name = "202", Number = 202 });
            rooms.Add(new RoomInfo { Name = "203", Number = 203 });
        }

        public GridControlViewModel()
        {
            setUpCustomerList();
            setUpRoomList();
            Genders.Add(new Gender { Name="Male"});
            Genders.Add(new Gender { Name = "Female" });
        }
    }
}
