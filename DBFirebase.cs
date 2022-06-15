using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using eShopOnContainers.Core.Models;
using Firebase.Database;
using Firebase.Database.Query;
using MvvmHelpers;
using eShopOnContainers.Core.Services.Odeme;

using Xamarin.Forms;


namespace eShopOnContainers.Core.Services.Odeme
{
	public class DBFirebase
	{
		FireBaseClient client;

		public DBFirebase()
        {
			client = new FireBaseClient("https://odemebilgi-f6799-default-rtdb.firebaseio.com/");
        }

		public ObservableCollection<Employee> getEmployee()
        {

			var odemeveri = client
				.Child("Employees")
				.AsObservable<Employee>()
				.AsObservableCollection();

			return odemeveri;
        }

		public async Task AddEmployee(string ad,string soyad,string kartNo ,int cVC)
        {
			Employee e = new Employee() { Ad = ad, Soyad = soyad, KartNo = kartNo, CVC = cVC };
			await client
				.Child("Employees")
				.PostAsync(e);


        }

	}
}

