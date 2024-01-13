using AutoMapper;
using ELibrary.Protos;

namespace ELibrary.Services
{
    internal class ELibraryProfile : Profile
    {
        public ELibraryProfile() 
        {
            CreateMap<UploadBookRequest, Shared.Book>();
            CreateMap<UpdateBookRequest, Shared.Book>();
            CreateMap<UploadCollectionRequest, Shared.Collection>();
            CreateMap<UpdateCollectionRequest, Shared.Collection>();
            CreateMap<Shared.Collection, GetCollectionResponse>();
            CreateMap<UploadScoreRequest, Shared.Score>();
            CreateMap<UploadCollectedRequest, Shared.CollectedBook>();
            CreateMap<Shared.CollectedBook, GetCollectedBookResponse>();
            CreateMap<UploadCommentRequest, Shared.Comment>();
            CreateMap<Shared.Comment, GetCommentResponse>();
            CreateMap<Shared.Book, GetBookResponse>();
            CreateMap<Shared.Book, GetBookDetailResponse>();
        }
    }
}
