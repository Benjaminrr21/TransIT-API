using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransIT.Application.DTOs;
using TransIT.Domain.Models;
using TransIT.Domain.Models.Users;

namespace TransIT.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<RegisterEmployeeDTO, Employee>();
            CreateMap<RegisterClientDTO, Client>();
            CreateMap<LoginEmployeeDTO, Employee>();
            CreateMap<LoginClientDTO, Client>();

            CreateMap<PackageDTO, Package>();
            CreateMap<Package, PackageInOrderDTO>();
            CreateMap<PackageWeightDTO, Package>();
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, ViewOrderDTO>();

            CreateMap<Client, ClientViewDTO>();

            CreateMap<VehicleDTO, Vehicle>();

            CreateMap<FactureDTO,Facture>();

        }
    }
}
