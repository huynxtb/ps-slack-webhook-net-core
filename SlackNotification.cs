using RestSharp;

namespace WebhookSlack;

public static class SlackNotification
{
    public static async Task SendMessageAsync(
        string webhookUrl
        , string title
        , SlackIcon slackIcon
        , string titleUrl
        , string content)
    {
        var client = new RestClient(webhookUrl);
        var request = new RestRequest() { Method = Method.Post };

        request.AddJsonBody(
            new
            {
                blocks = new List<object>()
                {
                    new
                    {
                        type = "section",
                        text = new
                        {
                            type = "mrkdwn",
                            text = $"*<{titleUrl}|{title.ToUpper()}>*"
                        }
                    },
                    new
                    {
                        type = "section",
                        text = new
                        {
                            type = "mrkdwn",
                            text = $"{content}"
                        },
                        accessory = new
                        {
                            type = "image",
                            image_url = $"{slackIcon.ReadDescription()}",
                            alt_text = "icon thumbnail"
                        }
                    }
                }
            }
        );
        var response = await client.ExecuteAsync(request);
    }
}