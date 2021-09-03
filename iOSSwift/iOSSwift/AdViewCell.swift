import UIKit
import GoogleMobileAds

class AdViewCell: UITableViewCell {
    func bind(item: Item) {
        if let nativeAdView = contentView as? GADNativeAdView {
            if let headlineLabel = nativeAdView.headlineView as? UILabel {
                headlineLabel.text = item.titulo
            }
            
            if let bodyLabel = nativeAdView.bodyView as? UILabel {
                bodyLabel.text = item.descricao
            }
        }
    }
}
