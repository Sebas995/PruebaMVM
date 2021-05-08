﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Prueba.BLL.Helper;
using PruebaMVM.DAL;
using PruebaMVM.DTO;
using PruebaMVM.DTO.ComunicacionDTO;
using PruebaMVM.Utilities.Logs;

namespace PruebaMVM.BLL
{
    public class ComunicacionBLL
    {
        ComunicacionDAL comunicacionDAL = new ComunicacionDAL();

        /// <summary>
        /// Obtiene las comunicaciones por Id
        /// </summary>
        /// <param name="Id">Id de la Comunicacion</param>
        /// <returns>Comunicacion</returns>
        public ComunicacionRes ObtenerComunicacionPorId(int Id)
        {
            ComunicacionRes comunicacion = new ComunicacionRes();
            try
            {
                comunicacion = comunicacionDAL.ObtenerComunicacionPorId(Id);
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }

            return comunicacion;
        }

        /// <summary>
        /// Obtiene las comunicaciones
        /// </summary>
        /// <returns>Comunicaciones</returns>
        public List<ComunicacionRes> ObtenerComunicaciones()
        {
            List<ComunicacionRes> comunicaciones = new List<ComunicacionRes>();
            try
            {
                comunicaciones = comunicacionDAL.ObtenerComunicaciones();
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }

            return comunicaciones;
        }

        /// <summary>
        /// Guarda las Comunicaciones
        /// </summary>
        /// <param name="comunicacionReq">Datos de la comunicacion</param>
        /// <returns>Datos de la comunicacion</returns>
        public ComunicacionRes GuardarComunicacion(ComunicacionReq comunicacionReq)
        {
            ComunicacionRes comunicacion = new ComunicacionRes();
            try
            {
                comunicacion = comunicacionDAL.GuardarComunicacion(comunicacionReq);
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }

            return comunicacion;
        }

        /// <summary>
        /// Editar las comunicaciones
        /// </summary>
        /// <param name="comunicacionReq"></param>
        /// <returns></returns>
        public void EditarComunicacion(ComunicacionReq comunicacionReq)
        {

            try
            {
                comunicacionDAL.EditarComunicacion(comunicacionReq);
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
        }

        /// <summary>
        /// Eliminar las comunicaciones
        /// </summary>
        /// <param name="comunicacionReq">Datos de la comunicacion</param>
        public void EliminarComunicacion(ComunicacionReq comunicacionReq)
        {
            try
            {
                comunicacionDAL.EliminarComunicacion(comunicacionReq);
            }
            catch (DataException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_DATABASE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (ArgumentException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_ARGUMENT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (NullReferenceException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_NULLREFERENCE.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (TimeoutException exc)
            {
                throw new MVMException(EnumMensajes.ERROR_TIMEOUT.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
            catch (Exception exc)
            {
                throw new MVMException(EnumMensajes.ERROR_EXCEPTION.ToString(), exc.GetType().ToString(), exc.Message, exc.StackTrace);
            }
        }
    }
}
