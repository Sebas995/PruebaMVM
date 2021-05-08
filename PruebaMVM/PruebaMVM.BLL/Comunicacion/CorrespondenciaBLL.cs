using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Prueba.BLL.Helper;
using PruebaMVM.DAL;
using PruebaMVM.DTO;
using PruebaMVM.DTO.CorrespondenciaDTO;
using PruebaMVM.Utilities.Logs;

namespace PruebaMVM.BLL
{
    /// <summary>
    /// CRUD de Correspondenciaes
    /// </summary>
    public class CorrespondenciaBLL
    {
        CorrespondenciaDAL CorrespondenciaDAL = new CorrespondenciaDAL();

        /// <summary>
        /// Obtiene las Correspondenciaes por Id
        /// </summary>
        /// <param name="Id">Id de la Comunicación</param>
        /// <returns>Comunicación</returns>
        public CorrespondenciaRes ObtenerCorrespondenciaPorId(int Id)
        {
            CorrespondenciaRes Correspondencia = new CorrespondenciaRes();
            try
            {
                Correspondencia = CorrespondenciaDAL.ObtenerCorrespondenciaPorId(Id);
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

            return Correspondencia;
        }

        /// <summary>
        /// Obtiene las Correspondenciaes
        /// </summary>
        /// <returns>Correspondenciaes</returns>
        public List<CorrespondenciaRes> ObtenerCorrespondenciaes()
        {
            List<CorrespondenciaRes> Correspondenciaes = new List<CorrespondenciaRes>();
            try
            {
                Correspondenciaes = CorrespondenciaDAL.ObtenerCorrespondenciaes();
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

            return Correspondenciaes;
        }

        /// <summary>
        /// Guarda las Correspondenciaes
        /// </summary>
        /// <param name="CorrespondenciaReq">Datos de la Correspondencia</param>
        /// <returns>Datos de la Correspondencia</returns>
        public CorrespondenciaRes GuardarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {
            CorrespondenciaRes Correspondencia = new CorrespondenciaRes();
            try
            {
                Correspondencia = CorrespondenciaDAL.GuardarCorrespondencia(CorrespondenciaReq);
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

            return Correspondencia;
        }

        /// <summary>
        /// Editar las Correspondenciaes
        /// </summary>
        /// <param name="CorrespondenciaReq">Datos de la Correspondencia</param>
        public void EditarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {

            try
            {
                CorrespondenciaDAL.EditarCorrespondencia(CorrespondenciaReq);
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
        /// Eliminar las Correspondenciaes
        /// </summary>
        /// <param name="CorrespondenciaReq">Datos de la Correspondencia</param>
        public void EliminarCorrespondencia(CorrespondenciaReq CorrespondenciaReq)
        {
            try
            {
                CorrespondenciaDAL.EliminarCorrespondencia(CorrespondenciaReq);
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
