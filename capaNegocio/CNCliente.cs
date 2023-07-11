﻿using capaEntidad;
using capaDatos;
using System.Data;

namespace capaNegocio
{
    public class CNCliente
    {
        CDClientes cDClientes = new CDClientes();
        public bool ValidarDatos(CEClientes cliente) 
        {
            bool Resultado = true;

            if (cliente.Nombre == string.Empty) 
            {
                Resultado = false;
                MessageBox.Show("El Nombre es obligatorio");
            }
            if (cliente.Apellido == string.Empty)
            {
                Resultado = false;
                MessageBox.Show("El Apellido es obligatorio");
            }
            if (cliente.Foto == null)
            {
                Resultado = false;
                MessageBox.Show("La foto es obligatorio");
            }
            return Resultado;
        }
        public void PruebaMySql()
        {
            cDClientes.PruebaConexion();
        }

        public void CrearCliente(CEClientes cE)
        {
            cDClientes.Crear(cE);
        }

        public DataSet ObtenerDatos ()
        {
            return cDClientes.Listar();
        }

        public void EditarCliente(CEClientes cE)
        {
            cDClientes.Editar(cE);
        }

        public void EliminarCliente(CEClientes cE)
        {
            cDClientes.Eliminar(cE);
        }

    }
}