namespace HloMoney.Core.Models.Enum
{
    public enum ContestType
    {
        /// <summary>
        /// Обычный розыгрыш без времени
        /// </summary>
        Standart,
        /// <summary>
        /// Обычный розыгрыш с ограничением по времени
        /// </summary>
        StandartTime,
        /// <summary>
        /// Розыгрыш с ограничением времени к последнему комментарию
        /// </summary>
        CommentTime,
        /// <summary>
        /// Глобальный розыгрыщ
        /// </summary>
        Global
    }
}
