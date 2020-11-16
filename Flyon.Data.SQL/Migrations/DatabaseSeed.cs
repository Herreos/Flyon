using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Flyon.Common.Enums;
using Flyon.Data.SQL.DAO;

namespace Flyon.Data.SQL.Migrations
{
    public class DatabaseSeed
    {
        private readonly FlyonDbContext _context;

        public DatabaseSeed(FlyonDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            #region CreateUser
            var userList = BuildUserList();
            _context.User.AddRange(userList);
            _context.SaveChanges();
            #endregion
            
            #region CreatePost
            var postList = BuildPostList();
            _context.Post.AddRange(postList);
            _context.SaveChanges();
            #endregion
            
            #region CreateReservation

            var reservationList = BuildReservationList();
            _context.Reservation.AddRange(reservationList);
            _context.SaveChanges();
            #endregion
            
            #region CreateRating
            var ratingList = BuildRatingList();
            _context.Rating.AddRange(ratingList);
            _context.SaveChanges();
            #endregion
            
            #region CreateComment
            var commentList = BuildCommentList();
            _context.Comment.AddRange(commentList);
            _context.SaveChanges();
            #endregion
        }
        

        private IEnumerable<DAO.User> BuildUserList()
        {
            var userList = new List<DAO.User>();
            var user1 = new DAO.User()
            {
                UserName = "bsurma",
                Password = "hokuspokus",
                Email = "b.surma@student.po.edu.pl",
                FirstName = "Bartosz",
                LastName = "Surma",
                Gender = Gender.Male,
                BirthDate = new DateTime(1998, 03, 10),
                RegistrationDate = new DateTime(2020, 02, 11),
                CurrentCountry = "Polska",
                CurrentCity = "Rybnik",
                CurrentStreetName = "Plebiscytowa",
                CurrentHouseNumber = "6",
                CurrentFlatNumber = null,
                UserRank = "Admin",
                IsActiveUser = true,
                IsBannedUser = false,
                IconHref = "https://scontent.fktw3-1.fna.fbcdn.net/v/t1.0-9/21558700_1319441458183582_769855901881946340_n.jpg?_nc_cat=107&_nc_sid=85a577&_nc_ohc=63k6HKaEPpYAX9O-spc&_nc_ht=scontent.fktw3-1.fna&oh=de00c3e91cc5c4e7920da11e870afd69&oe=5EAFDA7D"
            };
            userList.Add(user1);
            
            var user2 = new DAO.User()
            {
                UserName = "marian",
                Password = "marian123",
                Email = "mmarian@gmail.com",
                FirstName = "Marian",
                LastName = "Poniedzielski",
                Gender = Gender.Male,
                BirthDate = new DateTime(1939, 05, 15),
                RegistrationDate = new DateTime(2018, 11, 23),
                CurrentCountry = "Polska",
                CurrentCity = "Wrocław",
                CurrentStreetName = "Cwiartki",
                CurrentHouseNumber = "3",
                CurrentFlatNumber = "4",
                UserRank = "User",
                IsActiveUser = true,
                IsBannedUser = false,
                IconHref = "https://gfx.planeta.pl/var/planetapl/storage/images/rozrywka/piosenki-z-serialu-swiat-wedlug-kiepskich-pazdzioch-spiewa/2909111-1-pol-PL/Piosenki-Pazdziocha-z-serialu.-The-best-of!-WIDEO_article.jpg"
            };
            userList.Add(user2);
            
            var user3 = new DAO.User()
            {
                UserName = "rlewandowski",
                Password = "gool123",
                Email = "rlewandowski@gmail.com",
                FirstName = "Robert",
                LastName = "Lewandowski",
                Gender = Gender.Male,
                BirthDate = new DateTime(1988, 08, 21),
                RegistrationDate = new DateTime(2019, 10, 20),
                CurrentCountry = "Polska",
                CurrentCity = "Warszawa",
                CurrentStreetName = "Armii Krajowej",
                CurrentHouseNumber = "9",
                CurrentFlatNumber = null,
                UserRank = "User",
                IsActiveUser = true,
                IsBannedUser = false,
                IconHref = "https://cdn.galleries.smcloud.net/t/galleries/gf-BKbZ-rHYa-7L4W_robert-lewandowski-664x442-nocrop.jpg"
            };
            userList.Add(user3);
            
            var user4 = new DAO.User()
            {
                UserName = "zuza",
                Password = "zuzanna123",
                Email = "zkowalska@gmail.com",
                FirstName = "Zuzanna",
                LastName = "Kowalska",
                Gender = Gender.Female,
                BirthDate = new DateTime(1990, 04, 30),
                RegistrationDate = new DateTime(2017, 07, 03),
                CurrentCountry = "Polska",
                CurrentCity = "Toruń",
                CurrentStreetName = "Kopernika",
                CurrentHouseNumber = "31",
                CurrentFlatNumber = "2",
                UserRank = "User",
                IsActiveUser = true,
                IsBannedUser = false,
                IconHref = "https://www.odkrywamyzakryte.com/wp-content/uploads/2017/05/56999502_l.jpg"
            };
            userList.Add(user4);
            
            var user5 = new DAO.User()
            {
                UserName = "janek33",
                Password = "janusz123",
                Email = "jnowak@gmail.com",
                FirstName = "Janusz",
                LastName = "Nowak",
                Gender = Gender.Male,
                BirthDate = new DateTime(1967, 09, 25),
                RegistrationDate = new DateTime(2020, 02, 20),
                CurrentCountry = "Polska",
                CurrentCity = "Lublin",
                CurrentStreetName = "Lublińska",
                CurrentHouseNumber = "1",
                CurrentFlatNumber = null,
                UserRank = "User",
                IsActiveUser = true,
                IsBannedUser = false,
                IconHref = "https://i.pinimg.com/originals/e2/28/fb/e228fb666a93ceabd61f40f237a7c59c.jpg"
            };
            userList.Add(user5);
            
            var user6 = new DAO.User()
            {
                UserName = "ranyjulek",
                Password = "julek123",
                Email = "julek@gmail.com",
                FirstName = "Wacław",
                LastName = "Leopodolski",
                Gender = Gender.Male,
                BirthDate = new DateTime(1988, 09, 21),
                RegistrationDate = new DateTime(2020, 02, 21),
                CurrentCountry = "Polska",
                CurrentCity = "Szczecin",
                CurrentStreetName = "Młyńska",
                CurrentHouseNumber = "11",
                CurrentFlatNumber = null,
                UserRank = "User",
                IsActiveUser = true,
                IsBannedUser = false,
                IconHref = "https://i.pinimg.com/originals/e2/28/fb/e228fb666a93ceabd61f40f237a7c59c.jpg"
            };
            userList.Add(user6);
            
            return userList;
        }
        
        private IEnumerable<DAO.Post> BuildPostList()
        {
            var postList = new List<DAO.Post>();
            var post1 = new DAO.Post()
            {
                UserId = 1,
                CommentsCount = 2,
                RatesCount = 4,
                AverangeRate = 4.5,
                CreationDate = new DateTime(2020, 03,03, 10, 14, 55),
                EditionDate = new DateTime(2020, 03, 03, 10, 14, 55),
                OfferDescription = "Należący do naszej własnej sieci hoteli - White Olive Elite Rethymno to miejsce, gdzie najlepiej możemy zadbać o naszych Klientów.",
                OfferCountry = "Grecja",
                OfferCity = "Chania",
                OfferCost = 3722.00,
                OfferPhotoHref = "//images.r.pl/zdjecia/hotele/glob/4985/white-olive-elite-rethymno_grecja_kreta-chania_4985_118956_251548_1920x730.jpg",
                HotelName = "White Olive Elite Rethymno",
                DeparturePlace = "Lotnisko - Katowice",
                DateOfDeparture = new DateTime(2020, 07,05, 08, 45, 00),
                DateOfReturn = new DateTime(2020, 07,12, 07, 30, 00),
                IsActivePost = true,
                IsBannedPost = false
            };
            postList.Add(post1);
            
            var post2 = new DAO.Post()
            {
                UserId = 1,
                CommentsCount = 3,
                RatesCount = 3,
                AverangeRate = 4.0,
                CreationDate = new DateTime(2020, 04,02, 09, 45, 01),
                EditionDate = new DateTime(2020, 04, 02, 09, 45, 01),
                OfferDescription = "11 basenów, prywatna plaża z turkusowym wybrzeżem, komfortowo zaprojektowane pokoje, bogaty program dziennych i wieczornych animacji - to wszystko sprawi, że to będę Twoje niezapomniane, błogie wakacje!",
                OfferCountry = "Turcja",
                OfferCity = "Riwiera Turecka",
                OfferCost = 4507.00,
                OfferPhotoHref = "//images.r.pl/zdjecia/hotele/glob/4813/waterworld-belek-by-mp-hotels_turcja_riwiera-turecka_4813_121458_259605_1920x730.jpg",
                HotelName = "Aquaworld Belek By MP Hotels",
                DeparturePlace = "Lotnisko - Rzeszów",
                DateOfDeparture = new DateTime(2020, 07,15, 09, 15, 00),
                DateOfReturn = new DateTime(2020, 07,22, 10, 00, 00),
                IsActivePost = true,
                IsBannedPost = false
            };
            postList.Add(post2);

            var post3 = new DAO.Post()
            {
                UserId = 1,
                CommentsCount = 1,
                RatesCount = 2,
                AverangeRate = 4.0,
                CreationDate = new DateTime(2020, 01,01, 07, 30, 13),
                EditionDate = new DateTime(2020, 01, 01, 07, 30, 13),
                OfferDescription = "Wypoczynek w słonecznej Hurghdzie! Hotel all inclusive z siedmioma basenami oraz z wieloma ciekawymi miejscami turystycznymi wokół.",
                OfferCountry = "Egipt",
                OfferCity = "Hurghda",
                OfferCost = 3278.00,
                OfferPhotoHref = "//images.r.pl/zdjecia/hotele/glob/1416/symbole-egiptu-nil-i-piramidy_1416_99888_145205_1920x730.jpg",
                HotelName = "Hurghda Hotel",
                DeparturePlace = "Lotnisko - Katowice",
                DateOfDeparture = new DateTime(2020, 07,16, 05, 15, 00),
                DateOfReturn = new DateTime(2020, 07,24, 13, 30, 00),
                IsActivePost = true,
                IsBannedPost = false
            };
            postList.Add(post3);
            
            return postList;
        }
        
        private IEnumerable<Reservation> BuildReservationList()
        {
            var reservationList = new List<Reservation>();
            var reservation1 = new Reservation()
            {
                ReservationNumber = "DJA9302MAKL2",
                PostId = 1,
                UserId = 2,
                IsPaid = true
            };
            reservationList.Add(reservation1);
            
            var reservation2 = new Reservation()
            {
                ReservationNumber = "OIAJD9302459",
                PostId = 1,
                UserId = 4,
                IsPaid = true
            };
            reservationList.Add(reservation2);
            
            var reservation3 = new Reservation()
            {
                ReservationNumber = "IAODJOAIW839",
                PostId = 2,
                UserId = 3,
                IsPaid = true
            };
            reservationList.Add(reservation3);
            
            var reservation4 = new Reservation()
            {
                ReservationNumber = "9287432OJOAI",
                PostId = 3,
                UserId = 5,
                IsPaid = true
            };
            reservationList.Add(reservation4);
            
            return reservationList;
        }
        
        private IEnumerable<Rating> BuildRatingList()
        {
            var ratingList = new List<Rating>();
            
            var rate1 = new Rating()
            {
                UserId = 2,
                PostId = 1,
                RatingDate = new DateTime(2020, 03, 11, 10, 04, 54),
                Rate = 5.0
            };
            ratingList.Add(rate1);
            
            var rate2 = new Rating()
            {
                UserId = 3,
                PostId = 1,
                RatingDate = new DateTime(2020, 03, 11, 11, 24, 34),
                Rate = 4.0
            };
            ratingList.Add(rate2);
            
            var rate3 = new Rating()
            {
                UserId = 4,
                PostId = 1,
                RatingDate = new DateTime(2020, 03, 11, 13, 22, 56),
                Rate = 4.5
            };
            ratingList.Add(rate3);
            
            var rate4 = new Rating()
            {
                UserId = 5,
                PostId = 1,
                RatingDate = new DateTime(2020, 03, 13, 08, 01, 02),
                Rate = 4.5
            };
            ratingList.Add(rate4);
            
            var rate5 = new Rating()
            {
                UserId = 3,
                PostId = 2,
                RatingDate = new DateTime(2020, 02, 03, 16, 23, 04),
                Rate = 4.0
            };
            ratingList.Add(rate5);
            
            var rate6 = new Rating()
            {
                UserId = 5,
                PostId = 2,
                RatingDate = new DateTime(2020, 02, 04, 14, 20, 00),
                Rate = 3.5
            };
            ratingList.Add(rate6);
            
            var rate7 = new Rating()
            {
                UserId = 2,
                PostId = 2,
                RatingDate = new DateTime(2020, 02, 18, 19, 55, 55),
                Rate = 4.5
            };
            ratingList.Add(rate7);
            
            var rate8 = new Rating()
            {
                UserId = 3,
                PostId = 3,
                RatingDate = new DateTime(2020, 01, 17, 10, 01, 14),
                Rate = 4.0
            };
            ratingList.Add(rate8);
            
            var rate9 = new Rating()
            {
                UserId = 5,
                PostId = 3,
                RatingDate = new DateTime(2020, 01, 18, 10, 11, 11),
                Rate = 4.0
            };
            ratingList.Add(rate9);
            
            return ratingList;
        }
        
        private IEnumerable<Comment> BuildCommentList()
        {
            var commentList = new List<Comment>();
            
            var comment1 = new Comment()
            {
                ParentCommentId = null,
                PostId = 1,
                UserId = 2,
                CommentBody = "Byłem tam i było fajnie.",
                CommentDate = new DateTime(2020, 03, 12, 09, 30, 00),
                IsActiveComment = true,
                IsBannedComment = false
            };
            commentList.Add(comment1);
            
            var comment2 = new Comment()
            {
                ParentCommentId = null,
                PostId = 1,
                UserId = 3,
                CommentBody = "Polecam serdecznie to miejsce.",
                CommentDate = new DateTime(2020, 03, 13, 08, 30, 00),
                IsActiveComment = true,
                IsBannedComment = false
            };
            commentList.Add(comment2);
            
            var comment3 = new Comment()
            {
                ParentCommentId = null,
                PostId = 2,
                UserId = 2,
                CommentBody = "Świetna obsługa.",
                CommentDate = new DateTime(2020, 04, 12, 09, 30, 00),
                IsActiveComment = true,
                IsBannedComment = false
            };
            commentList.Add(comment3);
            
            var comment4 = new Comment()
            {
                ParentCommentId = null,
                PostId = 2,
                UserId = 4,
                CommentBody = "I jedzenie pycha.",
                CommentDate = new DateTime(2020, 04, 12, 11, 35, 04),
                IsActiveComment = true,
                IsBannedComment = false
            };
            commentList.Add(comment4);
            
            var comment5 = new Comment()
            {
                ParentCommentId = null,
                PostId = 2,
                UserId = 2,
                CommentBody = "Właśnie, jedzenie jeszcze, masz absolutną rację.",
                CommentDate = new DateTime(2020, 04, 12, 12, 55, 11),
                IsActiveComment = true,
                IsBannedComment = false
            };
            commentList.Add(comment5);
            
            var comment6 = new Comment()
            {
                ParentCommentId = null,
                PostId = 3,
                UserId = 2,
                CommentBody = "Idealne miejsce do wypoczynku z dziećmi.",
                CommentDate = new DateTime(2020, 01, 29, 12, 12, 12),
                IsActiveComment = true,
                IsBannedComment = false
            };
            commentList.Add(comment6);
            
            return commentList;
        }
    }
}