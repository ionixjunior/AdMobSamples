import UIKit

class AdViewCell: UITableViewCell {
    @IBOutlet weak var icon: UIImageView!
    @IBOutlet weak var headline: UILabel!
    @IBOutlet weak var body: UILabel!
    
    func bind(item: AdItem) {
        headline.text = item.titulo
        body.text = item.descricao
        icon.image = item.icone
    }
}
