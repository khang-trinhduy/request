using AutoMapper;
using Request.API.Controllers;
using Request.API.Model;
using Request.API.Models;
using Request.API.ViewModel;
using Request.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Request.API.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Model.Request, RequestEditModel>().ReverseMap();
            CreateMap<Model.Request, RequestViewModel>().ReverseMap();
            CreateMap<Model.Request, RequestExportModel>().ReverseMap();
            CreateMap<Model.Request, RequestCreateModel>().ReverseMap();
            CreateMap<State, StateEditModel>().ReverseMap();
            CreateMap<State, StateViewModel>().ReverseMap();
            CreateMap<State, StateExportModel>().ReverseMap();
            CreateMap<State, StateCreateModel>().ReverseMap();
            CreateMap<Node, NodeViewModel>().ReverseMap();
            CreateMap<Node, NodeCreateModel>().ReverseMap();
            CreateMap<State, StateViewModelSimplified>().ReverseMap();
            CreateMap<Node, NodeViewModelSimplified>().ReverseMap();
            CreateMap<Models.Action, ActionEditModel>().ReverseMap();
            CreateMap<Models.Action, ActionViewModel>().ReverseMap();
            CreateMap<Models.Action, ActionExportModel>().ReverseMap();
            CreateMap<Models.Action, ActionCreateModel>().ReverseMap();
            CreateMap<TLActivityOperator, ActivityViewModel>().ReverseMap();
            CreateMap<Activity, ActivityEditModel>().ReverseMap();
            CreateMap<Activity, ActivityViewModel>().Include<TLActivityOperator, ActivityViewModel>().ReverseMap();
            CreateMap<Activity, ActivityExportModel>().ReverseMap();
            CreateMap<Activity, ActivityCreateModel>().ReverseMap();
            CreateMap<Process, ProcessCreateModel>().ReverseMap();
            CreateMap<Role, RoleCreateModel>().ReverseMap();
            CreateMap<TransitionRule, RuleCreateModel>().ReverseMap();
            CreateMap<Email, DataViewModel>().ReverseMap();
            CreateMap<TLeave, DataViewModel>().ReverseMap();
            CreateMap<Comment, DataViewModel>().ReverseMap();
            CreateMap<Contact, DataViewModel>().ReverseMap();
            CreateMap<Campaign, DataViewModel>().ReverseMap();
            CreateMap<Data, DataViewModel>().Include<Email, DataViewModel>().Include<TLeave, DataViewModel>().Include<Comment, DataViewModel>().ReverseMap();

        }
    }
}
