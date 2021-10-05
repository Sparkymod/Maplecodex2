// Initializer
document.addEventListener("DOMContentLoaded", CopyToClipboard(), false);

function CopyToClipboard() {
    document.addEventListener('click', (e) => {
        // Message to show when copy.
        const message = "Copied!"

        // Event argument to be either e or window.event.
        e = e || window.event;

        // Store the click element.
        const target = e.target || e.srcElement;

        // We just want the table data clicked so we search by id.
        if (target.id === "itemTableId" && target.textContent != message) {
            text = target.textContent || target.innerText;

            // Copy the text to the clipboard.
            navigator.clipboard.writeText(text);

            // Add style when click for 3 seconds, then remove.
            target.classList.toggle("copied");
            target.textContent = message;
            setTimeout(function () {
                target.classList.toggle("copied");
                target.textContent = text;
            }, 2000);
        }
    }, false);
}