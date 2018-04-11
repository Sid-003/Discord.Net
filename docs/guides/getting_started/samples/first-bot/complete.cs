public class Program
{
	private DiscordSocketClient _client;
	
	public static void Main(string[] args)
		=> new Program().MainAsync().GetAwaiter().GetResult();

	public async Task MainAsync()
	{
		_client = new DiscordSocketClient();

		_client.Log += Log;
		_client.MessageReceived += MessageReceivedAsync;

		// Remember to keep this private or to read this
		// from an external source!
		string token = "abcdefg...";
		await _client.LoginAsync(TokenType.Bot, token);
		await _client.StartAsync();

		// Block this task until the program is closed.
		await Task.Delay(-1);
	}

	private async Task MessageReceivedAsync(SocketMessage message)
	{
		if (message.Content == "!ping")
		{
			await message.Channel.SendMessageAsync("Pong!");
		}
	}

	private Task Log(LogMessage msg)
	{
		Console.WriteLine(msg.ToString());
		return Task.CompletedTask;
	}
}