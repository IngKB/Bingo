namespace Bingo.Domain.ValueObjects
{
    public  class Coordenada
    {
        public int posX { get; set; }
        public int posY { get; set; }

        public Coordenada(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public bool SonCoordenadasIguales(Coordenada cord)
        {
            if(cord.posX == this.posX && cord.posY == this.posY)
            {
                return true;
            }
            return false;
        }
    }
}