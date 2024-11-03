function analisaXML(param) {
    var xmlDoc = new ActiveXObject("Msxml2.DOMDocument.3.0")
    xmlDoc.async = "false"
    xmlDoc.load(document.all("arqXML").value)
    if (xmlDoc.parseError.errorCode != 0) {
        msg = "Código do Erro: " + xmlDoc.parseError.errorCode + "\n"
        msg = msg + "Linha do Erro: " + xmlDoc.parseError.line + "\n"
        msg = msg + "Posição do Erro: " + xmlDoc.parseError.linepos + "\n"
        msg = msg + "Descrição do Erro: " + xmlDoc.parseError.reason
        alert(msg)
    }
    else {
        if (xmlDoc.validate() == 0)
            alert("XML bem formado e válido.")
        else {
            msg = "XML bem formado mas inválido " + "\n"
            alert(msg + "Erro - " + xmlDoc.validate().reason)
        }
    }
}