using AutoMapper;
using HotelBooking.API.Models;
using HotelBooking.Shared.DTO;

namespace HotelBooking.API.Profiles
{
    public class Profiles: Profile
    {
        public Profiles()
        {
            CreateMap<RoomType, RoomTypeDto>().ReverseMap();
            CreateMap<RoomType, RoomTypeAddDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Name)).ReverseMap();
            CreateMap<Room, RoomDto>().ForMember(desc => desc.RoomTypeName,
                opt => opt.MapFrom(src => src.RoomType.Name)).ReverseMap();
            CreateMap<RoomAddDto, Room>().ReverseMap();
            CreateMap<User, RegisterUserDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(src => src.Surname))
                .ForMember(
                dest => dest.EmailAddress,
                opt => opt.MapFrom(src => src.Email))
                .ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => src.PasswordHash));
            CreateMap<RegisterUserDto, User>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
                .ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(src => src.Surname))
                .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(
                dest => dest.PasswordHash,
                opt => opt.MapFrom(src => src.Password))
                .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => src.EmailAddress));
            CreateMap<User, UserDto>()
               .ForMember(
               dest => dest.Name,
               opt => opt.MapFrom(src => src.Name))
               .ForMember(
               dest => dest.Surname,
               opt => opt.MapFrom(src => src.Surname))
               .ForMember(
               dest => dest.EmailAddress,
               opt => opt.MapFrom(src => src.Email));
            CreateMap<Reservation, ReservationAddDto>().ReverseMap();
            CreateMap<ReservationDto, Reservation>();
            CreateMap<Reservation, ReservationDto>()
                .ForMember(
                dest => dest.StatusReservationName,
                opt => opt.MapFrom(src => src.StatusReservation.ToString()))
                .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => (src.User.Name + " " + src.User.Surname).ToString()))
                .ForMember(dest => dest.RoomNumber,
                opt => opt.MapFrom(src => src.Room.RoomNumber));

        }
    }
}
