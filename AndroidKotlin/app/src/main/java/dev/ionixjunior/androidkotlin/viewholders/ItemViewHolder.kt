package dev.ionixjunior.androidkotlin.viewholders

import android.view.View
import android.widget.TextView
import androidx.appcompat.widget.AppCompatImageView
import androidx.recyclerview.widget.RecyclerView
import dev.ionixjunior.androidkotlin.R
import dev.ionixjunior.androidkotlin.models.Item

class ItemViewHolder(view: View) : BaseViewHolder(view) {
    fun bind(item: Item) {
        titleView.text = item.title
        descriptionView.text = item.description
    }

    private val imageView: AppCompatImageView = view.findViewById<AppCompatImageView>(R.id.image)
    private val titleView: TextView = view.findViewById<TextView>(R.id.title)
    private val descriptionView: TextView = view.findViewById<TextView>(R.id.description)
}