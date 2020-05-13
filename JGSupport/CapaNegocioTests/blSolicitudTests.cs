using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Tests
{
    [TestClass()]
    public class blSolicitudTests
    {
        public blSolicitud controlador;
        public int id;

        [TestInitialize]
        public void TestInit()
        {
            id = 1;
            controlador = new blSolicitud();
        }

        [TestMethod()]
        public void ListarTest()
        {
        }

        [TestMethod()]
        public void ListarPorClienteTest()
        {
        }

        [TestMethod()]
        public void ObtenerListaPorIdTest()
        {

            int id = 2;
            List<Solicitud> lista = null;
            try
            {
                lista = controlador.ObtenerListaPorId(id);
                Assert.IsNotNull(lista);
                foreach (Solicitud solicitud in lista)
                {
                    Assert.IsTrue(solicitud.SolicitudId == id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod()]
        public void ObtenerPorSolicitudIdTest()
        {
            try
            {
                Solicitud solicitud = controlador.ObtenerPorSolicitudId(id);
                Assert.IsNotNull(solicitud);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [TestMethod()]
        public void ObtenerPorFormularioTest()
        {
        }

        [TestMethod()]
        public void FinalizarSolicitudIdTest()
        {
        }

        [TestMethod()]
        public void GuardarTest()
        {
          
        }
    }
}