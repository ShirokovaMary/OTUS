namespace SpaceBattleSrv
{
    /// <summary>
    /// Движущийся объект
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// Местоположение в пространстве
        /// </summary>
        Point Position 
        {
            get;
            set;
        }

        /// <summary>
        /// Вектор скорости движения
        /// </summary>
        Vector Velocity { get; }
    }
}