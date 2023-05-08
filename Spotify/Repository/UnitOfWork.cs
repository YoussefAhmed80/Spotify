using Spotify.Models;
using Spotify.Repository.Base;

namespace Spotify.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public Context Context;
        public UnitOfWork(Context _Context)
        {
            Context = _Context;

            SongRepository = new SongsRepository(Context);

            UserRepository = new Repository<User>(Context);

            CategoryRepository = new Repository<Category>(Context);

            LikesRepository = new LikesRepository(Context);

            PlayListRepository = new PlayListRepository(Context);

            ArtistRepository = new ArtistRepository(Context);

            ApplicationUserRepository = new ApplicationUserRepository(Context);

            PlayListSongRepository = new Repository<PlaylistSong>(Context);

            AlbumSongRepository = new AlbumSongRepository(Context);

            ListenDateRepository = new ListenDateRepository(Context);

            FollowerRepository = new FollowerRepository(Context);

            LikedSongsRepository = new LikedSongsRepository(Context);

            TypeRepository = new TypeRepository(Context);

            AlbumRepository =new AlbumRepository(Context);

            CategoryAlbumSongsRepository = new CategoryAlbumSongsRepository(Context);

            ArtistDetailsRepository = new ArtistDetailsRepository(Context);

            CategoryAlbumRepository = new CategoryAlbumRepository(Context);

        }


        public IPlayListRepository PlayListRepository { get; set; }

        public IRepository<User> UserRepository { get; set; }

        public IRepository<Category> CategoryRepository { get; set; }

        public ILikesrepository LikesRepository { get; set; }

        public IArtistRepository ArtistRepository { get; set; }

        public IApplicationUserRepository ApplicationUserRepository { get; set; }

        public ISongsRepository SongRepository { get; set; }

        public IRepository<PlaylistSong> PlayListSongRepository { get; set; }

        public IAlbumSongRepository AlbumSongRepository { get; set; }

        public IListenDateRepository ListenDateRepository { get; set; }

        public IFollowerRepository FollowerRepository { get; set; }

        public ILikedSongsRepository LikedSongsRepository { get; set; }

        public IAlbumRepository AlbumRepository { get; set; }

        public ITypeRepository TypeRepository { get; set; }

        public ICategoryAlbumSongsRepository CategoryAlbumSongsRepository { get; set; }

        public IArtistDetailsRepository ArtistDetailsRepository { get; set; }

        public ICategoryAlbumRepository CategoryAlbumRepository { get; set; }

        public int CommitChanges()
        {
            return Context.SaveChanges();
        }
    }
}

