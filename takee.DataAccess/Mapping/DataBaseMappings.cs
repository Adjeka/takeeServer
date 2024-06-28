using AutoMapper;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Mapping
{
    public class DataBaseMappings : Profile
    {
        public DataBaseMappings() 
        {
            CreateMap<AnimalEntity, Animal>();
            CreateMap<BreedEntity, Breed>();
            CreateMap<CuratorEntity, Curator>();
            CreateMap<FavouriteEntity, Favourite>();
            CreateMap<RecordForWalkEntity, RecordForWalk>();
            CreateMap<TypeOfAnimalsEntity, TypeOfAnimals>();
            CreateMap<UserEntity, User>();
            CreateMap<UserRoleEntity, UserRole>();
        }
    }
}
