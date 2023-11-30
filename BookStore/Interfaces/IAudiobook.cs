namespace BookStore.Interfaces;

public interface IAudiobook: IBook
{
    int? BookLength { get; set; }
}
