﻿using AutoMapper;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain.Estudiante;

namespace CIAC_TAS_Service.Mapping
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
            CreateMap<GetAllPostsQuery, GetAllPostsFilter>();
            CreateMap<CreateConfiguracionPreguntaAsaRequest, ConfiguracionPreguntaAsa>();
            CreateMap<UpdateConfiguracionPreguntaAsaRequest, ConfiguracionPreguntaAsa>();
            CreateMap<CreateEstudianteRequest, Estudiante>();
            CreateMap<UpdateEstudianteRequest, Estudiante>();
        }
    }
}
