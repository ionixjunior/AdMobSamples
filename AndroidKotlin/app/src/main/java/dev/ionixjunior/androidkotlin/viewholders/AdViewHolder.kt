package dev.ionixjunior.androidkotlin.viewholders

import android.view.View
import android.widget.TextView
import androidx.appcompat.widget.AppCompatImageView
import com.google.android.gms.ads.nativead.NativeAd
import dev.ionixjunior.androidkotlin.R

class AdViewHolder(view: View) : BaseViewHolder(view) {
    val imageView: AppCompatImageView = view.findViewById(R.id.image)
    val headlineView: TextView = view.findViewById(R.id.headline)
    val bodyView: TextView = view.findViewById(R.id.body)

    override fun bind(data: Any) {
        when (data) {
            is NativeAd -> {
                // TODO APLICAR O CONTEÚDO DA PROPAGANDA
            }
        }
    }
}