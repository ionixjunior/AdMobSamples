package dev.ionixjunior.androidkotlin.viewholders

import android.view.View
import android.widget.TextView
import androidx.appcompat.widget.AppCompatImageView
import androidx.recyclerview.widget.RecyclerView
import dev.ionixjunior.androidkotlin.R

class AdViewHolder(view: View) : BaseViewHolder(view) {
    val imageView: AppCompatImageView = view.findViewById(R.id.image)
    val headlineView: TextView = view.findViewById(R.id.headline)
    val bodyView: TextView = view.findViewById(R.id.body)
}