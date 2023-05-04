﻿using AngelValdiviezoWebApi.Application.Common.Exceptions;
using AngelValdiviezoWebApi.Application.Common.Interfaces;
using AngelValdiviezoWebApi.Application.Common.Wrappers;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Commands.CreateAcontecimientos;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Dto;
using AngelValdiviezoWebApi.Application.Features.Acontecimientos.Interfaces;
using AngelValdiviezoWebApi.Domain.Entities.Acontecimientos;
using AngelValdiviezoWebApi.Domain.Entities.Eventos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AngelValdiviezoWebApi.Persistence.Repository.Acontecimientos
{
    public class AcontecimientoService : IAcontecimientos
    {
        private readonly IRepositoryAsync<AcontecimientosModels> _repositoryAcontecimientoAsync;

        public AcontecimientoService(IRepositoryAsync<AcontecimientosModels> repositoryAcontecimientoAsync)
        {
            _repositoryAcontecimientoAsync = repositoryAcontecimientoAsync;
        }

        public async Task<ResponseType<AcontecimientosResponseType>> CreateAcontecimiento(CreateAcontecimientosRequest Request, CancellationToken cancellationToken)
        {
            try
            {
                var marcacionColaborador = DateTime.Now;
                AcontecimientosResponseType objResultFinal = new();

                AcontecimientosModels objAcont = new()
                {
                    idEvento = Request.IdEvento,
                    Descripcion = Request.Descripcion,
                    Fecha = Request.Fecha,
                    Lugar= Request.Lugar,
                    NumeroEntrada = Request.NumeroEntrada,
                    Precio = Request.Precio 
                };

                var objResultado = await _repositoryAcontecimientoAsync.AddAsync(objAcont, cancellationToken);
                if (objResultado is null)
                {
                    return new ResponseType<AcontecimientosResponseType>() { Message = "No se ha podido registrar su información", StatusCode = "101", Succeeded = true };
                }

                return new ResponseType<AcontecimientosResponseType>() { Data = objResultFinal, Message = "Marcación registrada correctamente", StatusCode = "100", Succeeded = true };

            }
            catch (Exception ex)
            {
                return new ResponseType<AcontecimientosResponseType>() { Message = CodeMessageResponse.GetMessageByCode("102"), StatusCode = "102", Succeeded = false };
            }


        }

    }
}
