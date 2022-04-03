
function handleNotification() {
	$.notification({
		title: 'New Mail',
		content: 'You have 20+ new mail in your Inbox',
		icon: 'fa fa-envelope',
		iconClass: 'bg-gradient-blue-indigo text-white'
	});
};


/* Controller
------------------------------------------------ */
$(document).ready(function() {
	handleNotification();
});