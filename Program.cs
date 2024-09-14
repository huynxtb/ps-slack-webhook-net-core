
using WebhookSlack;

var webhoobkURL = "https://hooks.slack.com/services/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";
var title = "Hello World 2";
var icon = SlackIcon.Error;
var titleUrl = "https://code-mega.com";
var content = "Have a nice day!!! \n *Code Mega*";

await SlackNotification.SendMessageAsync(webhoobkURL, title, icon, titleUrl, content);