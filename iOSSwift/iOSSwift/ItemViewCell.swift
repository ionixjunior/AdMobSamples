import UIKit

class ItemViewCell: UITableViewCell {
    @IBOutlet weak private var imagem: UIImageView!
    @IBOutlet weak private var titulo: UILabel!
    @IBOutlet weak private var descricao: UILabel!
    
    func bind(item: Item) {
        titulo.text = item.titulo
        descricao.text = item.descricao
    }
}
