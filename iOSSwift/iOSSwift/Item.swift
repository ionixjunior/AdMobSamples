import UIKit

class Item: BaseItem {
    var titulo: String
    var descricao: String
    
    init(titulo: String, descricao: String) {
        self.titulo = titulo
        self.descricao = descricao
    }
}
