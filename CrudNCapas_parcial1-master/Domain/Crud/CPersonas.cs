using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess.Entities;
using Common.Attributes;

namespace Domain.Crud
{
    public class CPersonas
    {
        Persona persona = new Persona(); //Declara un campo privado de tipo Persona llamado persona y lo inicializa con una nueva instancia de la clase Persona.

        public DataTable Mostrar() //Declara un método público llamado Mostrar que devuelve un objeto DataTable.
        {
            DataTable td = new DataTable(); //Declara una variable local de tipo DataTable llamada td e inicializa un nuevo DataTable
            td = persona.Mostrar(); //Llama al método Mostrar de la instancia persona de la clase Persona y asigna el resultado al DataTable td
            return td; //Devuelve el DataTable td que contiene los registros de personas
        }

        public DataTable Buscar(string Buscar)
        {
            DataTable td = new DataTable();
            td = persona.Buscar(Buscar); //Llama al método Buscar de la instancia persona de la clase Persona, pasando el parámetro Buscar, y asigna el resultado al DataTable td
            return td;
        }

        public void Insertar(AttributePeople obj)
        {
            persona.Insertar(obj); //Llama al método Insertar de la instancia persona de la clase Persona, pasando el objeto obj
        }

        public void Modificar(AttributePeople obj)
        {
            persona.Modificar(obj); //Llama al método Modificar de la instancia persona de la clase Persona, pasando el objeto obj
        }

        public void Eliminar(AttributePeople obj)
        {
            persona.Eliminar(obj); //Llama al método Eliminar de la instancia persona de la clase Persona, pasando el objeto obj
        }
    }
}
