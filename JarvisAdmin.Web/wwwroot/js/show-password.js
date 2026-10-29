// The Account pages render statically (no Blazor interactivity), so "Show password" checkboxes are
// wired up here. Delegated from document so it keeps working after Blazor's enhanced navigation
// swaps the page content.
document.addEventListener('change', function (e) {
    var targetId = e.target.getAttribute && e.target.getAttribute('data-show-password-for');
    if (!targetId) {
        return;
    }
    var input = document.getElementById(targetId);
    if (input) {
        input.type = e.target.checked ? 'text' : 'password';
    }
});
