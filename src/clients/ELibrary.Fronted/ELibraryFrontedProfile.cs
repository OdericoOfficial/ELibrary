using AutoMapper;
using Identities.Protos;
using static ELibrary.Fronted.Components.Shared.RegisterCard;
using static ELibrary.Fronted.Components.Shared.SignInCard;
using static ELibrary.Fronted.Components.Shared.BookListCard;
using static ELibrary.Fronted.Components.Shared.SearchCard;
using ELibrary.Protos;

namespace ELibrary.Fronted
{
    public class ELibraryFrontedProfile : Profile
    {
        public ELibraryFrontedProfile()
        {
            CreateMap<SignInModel, SignInRequest>();
            CreateMap<SignInResponse, UserModel>();
            CreateMap<RegisterModel, RegisterNoCaptchaRequest>();
            CreateMap<GetBookResponse, BookModel>();
        }
    }
}