import UIKit

class AdItem: BaseItem {
    var titulo: String
    var descricao: String
    var icone: UIImage?
    
    init(titulo: String, descricao: String, icone: UIImage?) {
        self.titulo = titulo
        self.descricao = descricao
        self.icone = icone
    }
}
