using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Prueba.BLL.Helper;
using PruebaMVM.Utilities.Logs;

namespace PruebaMVM.BLL
{
    public class Class1 : Logger
    {
        public void Data()
        {
            try
            {

            }
            catch (System.Data.DataException exc)
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
