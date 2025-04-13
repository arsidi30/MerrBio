using FarmIt.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Authorize]
public class ChatController : Controller
{
    private readonly DatabaseContext _context;

    public ChatController(DatabaseContext context)
    {
        _context = context;
    }

    public IActionResult Start(string recipient)
    {
        var sender = User.Identity.Name;

        var messages = _context.ChatMessages
            .Where(m => (m.SenderUsername == sender && m.RecipientUsername == recipient) ||
                        (m.SenderUsername == recipient && m.RecipientUsername == sender))
            .OrderBy(m => m.Timestamp)
            .ToList();

        ViewBag.Recipient = recipient;
        return View(messages);
    }
    [Authorize(Roles = "Fermer,Admin")]
    public IActionResult MyChats()
    {
        var currentUser = User.Identity.Name;

        var conversations = _context.ChatMessages
            .Where(m => m.SenderUsername == currentUser || m.RecipientUsername == currentUser)
            .Select(m => m.SenderUsername == currentUser ? m.RecipientUsername : m.SenderUsername)
            .Distinct()
            .ToList();

        return View(conversations);
    }


    [HttpPost]
    public IActionResult SendMessage(string recipient, string messageText)
    {
        var sender = User.Identity.Name;

        var message = new ChatMessage
        {
            SenderUsername = sender,
            RecipientUsername = recipient,
            MessageText = messageText,
            Timestamp = DateTime.Now
        };

        _context.ChatMessages.Add(message);
        _context.SaveChanges();

        return RedirectToAction("Start", new { recipient = recipient });
    }
}
