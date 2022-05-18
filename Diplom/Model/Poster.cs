using Diplom.Interfaces;

namespace Diplom.Model
{
    public class Poster : IPoster
    {
        public Guid Guid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public PosterState State { get; private set; }
        public PosterType Type { get; }
        public DateTime CreateDate { get; }

        public Poster(string name, string descrtiption, PosterType type, byte[] photo)
        {
            Guid = Guid.NewGuid();
            Name = name;
            Description = descrtiption;
            Type = type;
            Photo = photo;
        }

        public void Post()
        {
            State = PosterState.New;
        }

        public void Close()
        {
            State = PosterState.Closed;
        }

        public void Delete()
        {
            State = PosterState.Deleted;
        }

        public enum PosterType
        {
            Loss,
            Find
        }

        public enum PosterState
        {
            New,
            Open,
            Closed,
            Deleted
        }
    }
}
