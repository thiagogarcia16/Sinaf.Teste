using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sinaf.Teste.Domain.Entities;
using Sinaf.Teste.Domain.Interfaces.Repositories;
using Sinaf.Teste.Domain.Interfaces.Services;
using Sinaf.Teste.Domain.Notification;
using Sinaf.Teste.WebAPI.DTOs;
using System.Collections.Generic;

namespace Sinaf.Teste.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApoliceController : CustomControllerBase
    {
        private readonly IApoliceService ApoliceService;
        private readonly IMapper Mapper;
        private readonly IUnitOfWork UnitOfWork;

        public ApoliceController(IApoliceService apoliceService, IMapper mapper, 
                                 IUnitOfWork unitOfWork, NotificationContext notificationContext) : base(notificationContext)
        {
            this.ApoliceService = apoliceService;
            this.Mapper = mapper;
            this.UnitOfWork = unitOfWork;
        }      

        [HttpPost]
        public IActionResult PostApolice(ApoliceRequestDTO request)
        {
            var apolice = this.Mapper.Map<Apolice>(request);
            this.ApoliceService.Insert(apolice);          
            return Response(this.Mapper.Map<ApoliceInsertResponseDTO>(apolice));
        }

        [HttpGet]
        [Route("{clienteId:long}")]
        public ApoliceResponseDTO GetApolice(long clienteId)
        {             
            return Mapper.Map<ApoliceResponseDTO>(UnitOfWork.Apolices.Get(clienteId));
        }

        [HttpGet]
        public IEnumerable<ApoliceResponseDTO> GetAllApolices()
        {
            return Mapper.Map<IEnumerable<ApoliceResponseDTO>>(UnitOfWork.Apolices.GetAll());
        }

    }
}
