namespace MyTodo.Api.Application.AutoMapper
{
    public class MemoProfile : Profile
    {
        public MemoProfile()
        {
            CreateMap<Memo, MemoDto>();
        }
    }
}