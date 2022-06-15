function visitChildren(el) {
    const elements = document.getElementsByTagName(el)[0].children;

    console.log(document.getElementsByTagName(el)[0].tagName)

    for (let i = 0; i < elements.length; i++) {

        console.log(elements[i].tagName)
        
        if (elements[i].childElementCount !== 0) {
            visitChildren(elements[i].tagName)
        }
    }
}
