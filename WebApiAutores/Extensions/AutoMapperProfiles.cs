using AutoMapper;
using WebApiAutores.DTOS;
using WebApiAutores.Entidades;

namespace WebApiAutores.Extensions
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()// constructor d ela clase
        {
            //configuraciones de automapper
            CreateMap<ClassCreacionDTO, Class>();

            CreateMap<Class , ClassDTO>();
            CreateMap<Class, ClassCreacionDTO>();



        }


    }
}
