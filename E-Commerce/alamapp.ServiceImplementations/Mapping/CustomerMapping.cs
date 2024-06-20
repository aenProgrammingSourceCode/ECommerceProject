using alamapp.Model.Customers;
using alamapp.ServiceImplementations.ViewModel;
using alamapp.ServiceImplementations.ViewModel.Customers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.ServiceImplementations.Mapping
{
   public static class CustomerMapping
    {
       public static CustomerView ConvertToCustomerView(this Customer customer)
       {
           return Mapper.Map<Customer, CustomerView>(customer);
       }

       public static IEnumerable<PoliceStationView> ConvertToPoliceStationViews(this IEnumerable<PoliceStation> PoliceStations)
       {
           return Mapper.Map<IEnumerable<PoliceStation>, IEnumerable<PoliceStationView>>(PoliceStations);
       }
       public static PoliceStationView ConvertToPoliceStationView(this PoliceStation PoliceStation)
       {
           return Mapper.Map<PoliceStation, PoliceStationView>(PoliceStation);
       }

       public static IEnumerable<DistrictView> ConvertToDistrictViews(this IEnumerable<District> Districts)
       {
           return Mapper.Map<IEnumerable<District>, IEnumerable<DistrictView>>(Districts);
       }
       public static DistrictView ConvertToDistrictView(this District District)
       {
           return Mapper.Map<District, DistrictView>(District);
       }
    }
}
