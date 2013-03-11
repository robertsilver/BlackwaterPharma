function enact(what) {
	var p = what.parentNode;
	var els = p.parentElement.getElementsByTagName('LI');
	for (i = 0; i < els.length; i++) {
		els[i].className = '';
	}

	p.setAttribute("class", "current");
}

