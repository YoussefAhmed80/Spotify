using Spotify.Models;

namespace Spotify.Repository.Base
{
    public interface IUnitOfWork
    {
        

        IRepository<User> UserRepository { get; set; }
        
        IRepository<Category> CategoryRepository { get; set; }

        ILikesrepository LikesRepository { get; set; }

        IPlayListRepository PlayListRepository { get; set; }

        IArtistRepository ArtistRepository { get; set; }

        IApplicationUserRepository ApplicationUserRepository { get; set; }

        ISongsRepository SongRepository { get; set; }

        IRepository<PlaylistSong> PlayListSongRepository { get; set; }

        IAlbumSongRepository AlbumSongRepository { get; set; }

        IListenDateRepository ListenDateRepository { get; set; }

        IFollowerRepository FollowerRepository { get; set; }

        ILikedSongsRepository LikedSongsRepository { get; set; }

        IAlbumRepository AlbumRepository { get; set; }
        
        ITypeRepository TypeRepository { get; set; }

        ICategoryAlbumSongsRepository CategoryAlbumSongsRepository { get; set; }

        IArtistDetailsRepository ArtistDetailsRepository { get; set; }

        ICategoryAlbumRepository CategoryAlbumRepository { get; set; }

        int CommitChanges();
    }
}


        //IRepository<Song> SongRepository { get; set; }

        //IRepository<Artist> GetArtistRepository();
        //void SetArtistRepository(IRepository<Artist> value);