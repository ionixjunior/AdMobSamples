package dev.ionixjunior.androidkotlin.viewholders

import android.view.View
import android.widget.TextView
import androidx.appcompat.widget.AppCompatImageView
import androidx.recyclerview.widget.RecyclerView
import dev.ionixjunior.androidkotlin.R

class ItemViewHolder(view: View) : RecyclerView.ViewHolder(view) {
    val imageView: AppCompatImageView = view.findViewById<AppCompatImageView>(R.id.image)
    val titleView: TextView = view.findViewById<TextView>(R.id.title)
    val descriptionView: TextView = view.findViewById<TextView>(R.id.description)
}