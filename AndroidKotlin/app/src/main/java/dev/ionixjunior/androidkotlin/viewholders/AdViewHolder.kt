package dev.ionixjunior.androidkotlin.viewholders

import android.view.View
import android.widget.TextView
import androidx.appcompat.widget.AppCompatImageView
import dev.ionixjunior.androidkotlin.R
import dev.ionixjunior.androidkotlin.models.Ad

class AdViewHolder(view: View) : BaseViewHolder(view) {
    private val imageView: AppCompatImageView = view.findViewById(R.id.image)
    private val headlineView: TextView = view.findViewById(R.id.headline)
    private val bodyView: TextView = view.findViewById(R.id.body)

    override fun bind(data: Any) {
        when (data) {
            is Ad -> {
                imageView.setImageDrawable(data.image)
                headlineView.text = data.headline
                bodyView.text = data.body
            }
        }
    }
}