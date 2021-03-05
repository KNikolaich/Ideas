namespace PoolsApi.Data
{
    /// <summary>
    /// Методы запроса
    /// </summary>
    /// <remarks>названия с маленькой буквы с целью , чтобы они совпадали с запросами в Ethirmine
    /// Понимаю, что быдлятина, но трансформацию пока писать лениво</remarks>
    public enum RequestMethodEnum
    {
        currentHashrate,
        averageHashrate,
        // accountBalance,
        unpaid,
    }
}